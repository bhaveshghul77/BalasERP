namespace InfoShark.Helper
{
    public static class StoredProcedure
    {
        public static string GetQueryName(string module, string action = "")
        {
            if (module.Equals("User"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetUserMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllUserMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_UserMaster]";
                }
            }
            else if (module.Equals("State"))
            {
                if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllStateList]";
                }
            }
            else if (module.Equals("City"))
            {
                if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetCityByStateIdList]";
                }
            }
            else if (module.Equals("Group"))
            {
                if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllGroupList]";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetGroupByUserIdList]";
                }
            }
            else if (module.Equals("Menu"))
            {
                if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllMenuList]";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetMenuByGroupIdList]";
                }
            }
            else if (module.Equals("GroupRight"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetGroupRightsMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_GroupRightsMaster]";
                }
            }
            else if (module.Equals("UserRight"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetUserRightsMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_UserRightsMaster]";
                }
            }

            return string.Empty;
        }
    }
}
