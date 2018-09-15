﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Web.Api
{
    public enum ActionTypes
    {
        DefaultAction,
        MoveAction,
        AttackAction,
        CollectAction,
        UpgradeAction,
        StealAction,
        PurchaseAction,
        HealAction
    }

    public enum UpgradeType
    {
        CarryingCapacity,
        AttackPower,
        Defence,
        MaximumHealth,
        CollectingSpeed
    }

    public enum PurchasableItem
    {
        MicrosoftSword,
        UbisoftShield,
        DevolutionsBackpack,
        DevolutionsPickaxe,
        HealthPotion,
    }

    // DO NO REORDER THIS, make sure it matches the typescript tile enum.
    public enum TileType
    {
        Tile,
        Wall,
        House,
        Lava,
        Resource,
        Shop
    }

    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public static Point operator -(Point pt1, Point pt2)
        {
            return new Point(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static Point operator +(Point pt1, Point pt2)
        {
            return new Point(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", X, Y);
        }
    }

    public struct GameInfo
    {
        public PrivatePlayerInfo Player;
        public string CustomSerializedMap;
        public List<KeyValuePair<string, PublicPlayerInfo>> OtherPlayers;
    }

    public class Tile
    {
        public TileType TileType
        {
            get
            {
                return (TileType)C;
            }
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        private byte C;

        public Tile(byte content, int x, int y)
        {
            C = content;
            X = x;
            Y = y;
        }
    }

    public class PrivatePlayerInfo
    {
        public PrivatePlayerInfo(int health, int maxHealth, Point position, Point houseLocation, int score, int carriedResources, int carryingCapacity)
        {
            Health = health;
            MaxHealth = maxHealth;
            Position = position;
            HouseLocation = houseLocation;
            Score = score;
            CarriedResources = carriedResources;
            CarryingCapacity = carryingCapacity;
        }

        public int Health;
        public int MaxHealth;
        public int CarriedResources;
        public int CarryingCapacity;
        public Point Position;
        public Point HouseLocation;
        public int Score;
    }

    public class PublicPlayerInfo
    {
        public PublicPlayerInfo(int health, int maxHealth, Point position)
        {
            Health = health;
            MaxHealth = maxHealth;
            Position = position;
        }

        public int Health;
        public int MaxHealth;
        public Point Position;
    }
}
