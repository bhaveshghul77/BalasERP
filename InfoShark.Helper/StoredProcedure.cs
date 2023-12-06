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
            else if (module.Equals("Login"))
            {
                return "[dbo].[ValidateUserbyUsernameAndPassword]";
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
            else if (module.Equals("Millimetre"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetMillimetreMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllMillimetreMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_MillimetreMaster]";
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

            else if (module.Equals("DataInput"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetDataInputMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllDataInputMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_DataInputMaster]";
                }
            }
            else if (module.Equals("DataInputOption"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetDataInputOptionMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return ""; //[dbo].[GetAllDataInputOptionMasterList]
                }
                else
                {
                    return "[dbo].[CURD_DataInputOptionMaster]";
                }
            }

            else if (module.Equals("TypeofBackdata"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetTypeofBackdataMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllTypeofBackdataMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_TypeofBackdataMaster]";
                }
            }
            else if (module.Equals("TypeofBackdataOption"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetTypeofBackdataOptionMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetTypeofBackdataOptionMasterListByTypeofBackdataId]";
                }
                else
                {
                    return "[dbo].[CURD_TypeofBackdataOptionMaster]";
                }
            }
            else if (module.Equals("Backdata"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetBackDataMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetBackDataMasterListByTypeofBackdataOptionId]";
                }
                else
                {
                    return "[dbo].[CURD_BackDataMaster]";
                }
            }

            else if (module.Equals("TypeofHardware"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetTypeofHardwareMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "[dbo].[GetAllTypeofHardwareMasterList]";
                }
                else
                {
                    return "[dbo].[CURD_TypeofHardwareMaster]";
                }
            }
            else if (module.Equals("TypeofHardwareOption"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetTypeofHardwareOptionMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetTypeofHardwareOptionMasterListByTypeofHardwareId]";
                }
                else
                {
                    return "[dbo].[CURD_TypeofHardwareOptionMaster]";
                }
            }
            else if (module.Equals("Hardware"))
            {
                if (action.Equals("GetListofData"))
                {
                    return "[dbo].[GetHardwareMasterList]";
                }
                else if (action.Equals("GetList"))
                {
                    return "";
                }
                else if (action.Equals("GetListWithParam"))
                {
                    return "[dbo].[GetHardwareMasterListByTypeofHardwareOptionId]";
                }
                else
                {
                    return "[dbo].[CURD_HardwareMaster]";
                }
            }

            return string.Empty;
        }
    }
}
