function search(low, high, key) {//low是开始编号，high为结束便还，key为要查找的值
    var guesspath;//记录查找的过程
    while (low <= high) {//继续查找的条件是起始编号比结束编号小，如果起始编号比结束编号还大，则结束查找。
        var mid = parseInt((high + low) / 2);//找到中间的灯泡编号mid，并将小数转化成整数，万用表的负极接在该灯泡上
        if (low == mid) {//当万用表的正负极都在一个灯泡上时才能唯一确定该灯泡是不是坏的
            if (key == mid) {//灯泡不亮
                guesspath = recordPath(guesspath, low, key, high);//记录
                alert("找到了。猜测过程为" + guesspath);//找到要查找的数，显示查找的过程
                break;//找到了，不再查找
            } else {//灯泡亮
                low = low + 1;
            }
        } else if (key > mid) {//万用表的正负极都在不同的灯泡上且灯泡亮
            low = mid + 1;//改变查找范围的最小值
        } else if (key <= mid) {//万用表的正负极都在不同的灯泡上且灯泡不亮
            high = mid;//改变查找范围的最大值
        }
        guesspath = recordPath(guesspath, low, key, high);//记录
    }
    if (low > high) {//如果结束查找时最小数比最大数还大，说明没有找到，弹出提示。
        alert("在当前数列中没有发现要找的数。猜测过程为" + guesspath);
    }
    return guesspath;
}

//记录查找的历史记录
function recordPath(oldpath, low, mid, high) {
    if (oldpath == "") {
        return low + "-" + high + ":" + mid;
    } else {
        return oldpath + "," + low + "-" + high + ":" + mid;
    }
}