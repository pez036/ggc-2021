using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRail : MonoBehaviour {
    /// <summary>
    /// 铁轨长度
    /// </summary>
    public float railLength;

    /// <summary>
    /// 连接表 轨道的四个方向分别连接的下一节轨道 不相连接的轨道为null
    /// </summary>
    public Dictionary<Position.Direction, BaseRail> connection;

    /// <summary>
    /// 需要复写，表明这条铁轨的传递方向
    /// </summary>
    public abstract Position.Direction ToGo(Position.Direction direction);

    /// <summary>
    /// 传入车厢信息 返回车厢当前姿态(位置坐标与旋转朝向)
    /// </summary>
    /// <param name="wagon"></param>
    /// <returns></returns>
    public TransformStatus CurrentStatus (float progress) {
        // TODO
        return new TransformStatus();
    }

}
