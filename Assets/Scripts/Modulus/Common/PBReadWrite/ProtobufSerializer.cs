using ProtoBuf;
using System.IO;

/// <summary>
/// Protobuf_net
/// </summary>
public class ProtobufSerializer
{
    /// <summary>
    /// 序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static byte[] Serialize<T>(T t)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<T>(ms, t);
            //定义二级制数组，保存序列化后的结果
            byte[] result = new byte[ms.Length];
            //将流的位置设为0，起始点
            ms.Position = 0;
            //将流中的内容读取到二进制数组中
            ms.Read(result, 0, result.Length);
            return result;

        }
    }
    /// <summary>
    /// 反序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    /// <returns></returns>
    public static T DeSerialize<T>(byte[] buffer)
    {
        using (MemoryStream ms = new MemoryStream(buffer))
        {
            T t = Serializer.Deserialize<T>(ms);
            return t;
        }
    }
}

