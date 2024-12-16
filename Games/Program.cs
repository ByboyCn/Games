// See https://aka.ms/new-console-template for more information
using Games;

Console.WriteLine("Hello, World!");
Events.Receive += Events_Receive;

Task Events_Receive(WsPacket e)
{
    Console.WriteLine($"收到消息{e.Cmd}");
    if (e.Cmd == 607) {

    }
    return Task.CompletedTask;
}

var b = await WsHelper.Connect();
if (b) {

    var zoolId = 46567;
    var accountId = 1557938566;
    cmLogin cmLogin = new() {
        PlayerId = 200005300011398,
        Password = "1077103007710119477",
        ClientType = 1,
        FriendId = 0,
        Latitude = "",
        Longitude = "",
        ClientVer = 2024112501,
        DeviceModel = "",
        DeviceId = "",
        NetworkType = "",
        MacAddress = "",
        PackageId = "",
        UrlId = "200000001",
        BigChannelId = "2000000",
        LangType = "zh-cn",
        Ewcid = 1446
    };
    await WsHelper.Send(new WsPacket { AccountId = accountId,Cmd = 10001,ZoneId = zoolId,PbMessage = cmLogin });

    while (true) {

        //输出，请输入操作命令
        Console.WriteLine("请输入操作命令");
        //接收输入
        var cmd = Console.ReadLine();
        //sw判断输入
        switch (cmd) {
            case "1": {
                    cmRecevGold cmRecevGold = new() { CritNum = 1,RecevNum = 1,GoldNum = "100000" };
                    await WsHelper.Send(new WsPacket { AccountId = accountId,Cmd = 20607,ZoneId = zoolId,PbMessage = cmRecevGold });
                }
                break;
            default:
                break;
        }
    }
}

Console.Read();
