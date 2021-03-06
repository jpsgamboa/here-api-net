﻿using HereAPI.Shared.Requests.Helpers;
using HereAPI.Shared.Structure;
using System.ComponentModel;

namespace HereAPI.Routing.TypesCommon
{
    public class LinkId : IAttribute
    {
        public static char[] DIRECTION_SYMBOLS = { '+', '-', '*' };

        public enum LinkDirection
        {
            [Description("+")] To,
            [Description("-")] From,
            [Description("*")] Any
        }

        public int Id { get; set; }
        public LinkDirection Direction { get; set; }

        public LinkId(int linkID, LinkDirection linkDirection)
        {
            Id = linkID;
            Direction = linkDirection;
        }

        public string GetAttributeValue()
        {
            return $"{EnumHelper.GetDescription(Direction)}{Id}";
        }

        public string[] Validate()
        {
            return AttributeValidator.Validate(this);
        }
    }
}