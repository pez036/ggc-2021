using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour{

    /// <summary>
    /// 在当前铁轨上的进程
    /// </summary>
    public float progress;

    /// <summary>
    /// 当前所在的铁轨
    /// </summary>
    public BaseRail railOn;

    /// <summary>
    /// 火车正向进入铁轨的方向。如果火车是退回来的，不会以火车退过来的方向，始终是以火车前进方向为准
    /// </summary>
    public Position.Direction enterDirection;

    /// <summary>
    /// 在铁轨上的移动速度，单位还没确定
    /// </summary>
    /// TODO 从Velocity中获取具体的速度
    public float Speed { get {
            return 1f;
        }
    }


    /// <summary>
    /// 向前移动列车
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="enterDirection"></param>
    /// <returns></returns>
    public void MoveForward() {

        // 当前进程增加速度
        progress += Speed;

        while (true) {
            // 火车已经进入了下一节轨道
            if (progress >= railOn.railLength) {

                // 处理溢出量
                progress -= railOn.railLength;

                // 改变火车当前所在轨道
                railOn = railOn.connection[railOn.ToGo(enterDirection)];

                // 改变火车当前进入的方向信息
                // ToGo是指向的方向，必须要再取对面才是火车正确的进入方向
                enterDirection = Position.Opposite(railOn.ToGo(enterDirection));
            }

            // 火车退回了上一轨道
            else if (progress < 0) {
                // 改变火车当前所在轨道
                railOn = railOn.connection[enterDirection];

                // 处理溢出量  前面一段铁轨总厂减去退回去的进度，差不多
                progress -= railOn.railLength + progress; // 这里的progress正好是负数

                // 改变火车当前进入的方向信息
                // 先进入方向取反假装自己是正常进来的，然后取TOGO为再后退的方向，再取反，为正方向
                // TODO 可能有错
                enterDirection = Position.Opposite(railOn.ToGo(Position.Opposite(enterDirection)));
            }

            //火车仍然在轨道中
            else if (progress >= 0 && progress < railOn.railLength) {
                // 不用做处理
                return;
            }
        }

    }



    // 每帧调用
    private void Update() {
        MoveForward();
        var tranformStats = railOn.CurrentStatus(progress);
    }
}
