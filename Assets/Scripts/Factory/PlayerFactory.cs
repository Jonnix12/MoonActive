using System;
using System.Collections.Generic;
using MoonActive.Connect4;
using MoonActive.Players;
using UnityEngine;

namespace MoonActive.Factorys
{
    public class PlayerFactory
    {
        public BasePlayer GetPlayer(string name, int id, PlayerType playerType, DiskType diskType)
       {
           switch (playerType)
           {
               case PlayerType.PlayerLocal:
                   return new LocalPlayer(new PlayerData(name,id,playerType,diskType),GetDiskType(diskType));
               case PlayerType.AI:
                   return new AIPlayer(new PlayerData(name,id,playerType,diskType),GetDiskType(diskType));
               case PlayerType.PlayerOnline:
                   break;
               default:
                   return null;
           }

           return null;
       }
       
       public List<BasePlayer> GetPlayers(params PlayerData[] playerDatas)
       {
           List<BasePlayer> output = new List<BasePlayer>(playerDatas.Length);
           
           foreach (var playerData in playerDatas)
           {
               output.Add(GetPlayer(playerData.Name, playerData.ID, playerData.PlayerType, playerData.DiskType));
           }

           return output;
       }

       private Disk GetDiskType(DiskType diskType)
       {
           return diskType switch
           {
               DiskType.Red => Resources.Load<Disk>($"Disks/Disk_A"),
               DiskType.Blue => Resources.Load<Disk>($"Disks/Disk_B"),
               _ => throw new ArgumentOutOfRangeException()
           };
       }
    }
    
    public enum PlayerType
    {
        PlayerLocal,
        AI,
        PlayerOnline
    }

    public enum DiskType
    {
        Blue,
        Red
    }
}