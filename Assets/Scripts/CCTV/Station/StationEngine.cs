/********************************************************************************
** Coder：    ???

** 创建时间： 2019-03-07 11:13:38

** 功能描述:  ???

** version:   v1.2.0

*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StationEngine : MonoBehaviour
{
	#region 锁
	
	#endregion

	#region 单例
    private static StationEngine m_instance = null;
    public static StationEngine Instance
    {
        get { return m_instance; }
    }
	#endregion

    #region 字段
    private StationMgr m_stationMgr = null;
    #endregion

    #region 属性
    public StationMgr StationMgr
    {
        get { return m_stationMgr; }
    }
    #endregion

	#region Unity生命周期
    void Awake()
    {
        m_instance = this;
        Init();
    }
	#endregion

    #region IModule方法实现
    public void Init()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        m_stationMgr = ReadStationPoint.BuildStationPoint();
		ReadStationPoint.AAA(m_stationMgr);
        ReadStationPoint.BuildStationDevices(m_stationMgr);
        sw.Stop();
        TimeSpan ts2 = sw.Elapsed;
        UnityEngine.Debug.Log("sw总共花费" + ts2.TotalMilliseconds + "ms.");
    }
    public void Release()
    {

    }
    #endregion

	#region 方法
    public Point GetNoReservationPoint(int stationIndex, int pointStatus, int queueIndex)
    {
        Point point = m_stationMgr.GetNoReservationPoint(stationIndex, pointStatus, queueIndex);
        return point;
    }
	public Point GetEmptyPoint(int stationIndex, int pointStatus, int queueIndex)
	{
		Point point = m_stationMgr.GetEmptyPoint(stationIndex, pointStatus, queueIndex);
		return point;
	}
	public Point GetEmptyPoint(int stationIndex, int pointStatus)
	{
		Point point = m_stationMgr.GetEmptyPoint(stationIndex, pointStatus);
		return point;
	}
    //获取队列最后一个位置点
    public Point GetLastPoint(int stationIndex, int pointStatus, int queueIndex)
    {
        Point point = m_stationMgr.GetLastPoint(stationIndex, pointStatus, queueIndex);
        return point;
    }
    //获取某个指定的站台
    public Station GetStation(int stationIndex)
    {
        Station station = m_stationMgr.GetStation(stationIndex);
        return station;
    }
    //获取指定站台的某个PointStatus的PointQueueHash
    public PointQueueHash GetPointQueueHash(int stationIndex, int pointStatus)
    {
        Station station = GetStation(stationIndex);
        if(station == null) return null;
        PointQueueHash pointQueueHash = station.GetPointQueueHash(pointStatus);
        return pointQueueHash;
    }
	#endregion

    #region 新增
    //随机获取一个PointQueue队列，并取出该PointQueue中的第一个位置点
    public Point GetFirstPoint2RandomPointQueue(int stationIndex, int pointStatus)
    {
        return m_stationMgr.GetFirstPoint2RandomPointQueue(stationIndex, pointStatus);
    }
    //随机获取一个PointQueue队列, 并取出首个NoReservation的位置点
    public Point GetNoReservationPoint2RandomPointQueue(int stationIndex, int pointStatus)
    {
        return m_stationMgr.GetNoReservationPoint2RandomPointQueue(stationIndex, pointStatus);
    }
    //随机获取一个位置点, 针对休息区
    public Point GetRandomNoReservationPointAtRestArea(int stationIndex, int pointStatus)
    {
        return m_stationMgr.GetRandomNoReservationPointAtRestArea(stationIndex, pointStatus);
    }
    //获取队列第一个位置点
    public Point GetFirstPoint(int stationIndex, int pointStatus, int queueIndex)
    {
        return m_stationMgr.GetFirstPoint(stationIndex, pointStatus, queueIndex);
    }
    //获取未被预约的Point, 返回的首先是队列最后边没有被预约的位置点
    public Point GetReverseNoReservationPointByQueueIndex(int stationIndex, int pointStatus, int queueIndex)
    {
        return m_stationMgr.GetReverseNoReservationPointByQueueIndex(stationIndex, pointStatus, queueIndex);
    }
    #endregion
}