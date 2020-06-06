using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;

namespace BG.SharePoint.Test
{
    public class ListUtil
    {
        const string dataListID  = "73efb71f-4f32-4bae-ad13-06eefc64c313";        
        const string colorListID = "f6a0b943-68c1-4b63-9e7e-31b14fb32eed";

        public bool CreateDataListItem(string title, string firstNumber, string lastNumber, string color, ResponseModel model)
        {  
            bool result = false;
           
            var siteId = SPContext.Current.Site.ID;
            var webId = SPContext.Current.Web.ID;

            model.SiteId = siteId;
            model.WebId = webId;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite site = new SPSite(siteId))
                using (SPWeb web = site.OpenWeb(webId))
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;

                        model.SiteUrl = site.Url;
                        model.WebUrl = web.Url;

                        SPList dataList = GetListByRelariveUrlOrId(web, dataListID);
                        
                        if (dataList != null)
                        {                            
                            for (int i = Convert.ToInt32(firstNumber); i <= Convert.ToInt32(lastNumber); i++)
                            {
                                SPQuery query = new SPQuery();
                                query.Query = string.Format(@"
                                            <Where>
                                                    <Eq>
                                                        <FieldRef Name='Номер' />
                                                        <Value Type='Text'>{0}</Value>
                                                    </Eq>
                                            </Where>", i.ToString());

                                SPListItemCollection items = dataList.GetItems(query);
                                if (items.Count < 1 )
                                {
                                    SPListItem newSPListItem = dataList.Items.Add();
                                    newSPListItem["Номер"] = i.ToString();
                                    newSPListItem["Название"] = title;

                                    SPList colorList = GetListByRelariveUrlOrId(web, dataListID);

                                    SPQuery queryColor = new SPQuery();
                                    queryColor.Query = string.Format(@"
                                            <Where>
                                                    <Eq>
                                                        <FieldRef Name='Название' />
                                                        <Value Type='Text'>{0}</Value>
                                                    </Eq>
                                            </Where>", color);

                                    SPListItemCollection itemsColor = colorList.GetItems(queryColor);
                                    if (itemsColor.Count > 0)
                                    {
                                        SPListItem coloritem = itemsColor[0];                                        
                                        newSPListItem["Цвет"] = coloritem.ID;
                                    };
                                    newSPListItem.Update();
                                }
                            }
                            result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        model.Message = ex.Message;
                        Utilities.Log("BG: ", ex.ToString());                
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            });

            return result;
        }


        public bool CreateColorListItem( string color, ResponseModel model)
        {
            bool result = false;

            try
            {
                var siteId = SPContext.Current.Site.ID;
                var webId = SPContext.Current.Web.ID;

                model.SiteId = siteId;
                model.WebId = webId;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite site = new SPSite(siteId))
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        model.SiteUrl = site.Url;
                        model.WebUrl = web.Url;

                        SPList colorList = GetListByRelariveUrlOrId(web, colorListID);

                        if (colorList != null)
                        {
                            
                         SPListItem newSPListItem = colorList.Items.Add();                                
                         newSPListItem["Название"] = color;
                         newSPListItem.Update();
                         result = true;
                        }
                    }
                });


            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
                Utilities.Log("BG: ", ex.ToString());
                return result;
            }

            return result;

        }


        public IEnumerable<Color> GetColors()
        {    
            List<Color> result = new List<Color>();

            try
            {
                var siteId = SPContext.Current.Site.ID;
                var webId = SPContext.Current.Web.ID;

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite site = new SPSite(siteId))
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        SPList colorList = GetListByRelariveUrlOrId(web, colorListID);

                        if (colorList != null)
                        {
                            SPListItemCollection items = colorList.GetItems();
                            foreach (SPListItem item in items)
                            {
                                Color color = new Color() { Title = item["Название"].ToString() };
                                result.Add(color);
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {                
                Utilities.Log("BG: ", ex.ToString());
                return result;
            }           

            return result;
        }



        public static SPList GetListByRelariveUrlOrId(SPWeb web, string listRelativeUrlOrID)
        {
            SPList list = null;
            Guid listID = Guid.Empty;
            Guid.TryParse(listRelativeUrlOrID, out listID);
            if (listID != Guid.Empty)
            {
                list = web.Lists.GetList(listID, true);
            }
            else
            {
                list = web.GetList(SPUrlUtility.CombineUrl(web.ServerRelativeUrl, listRelativeUrlOrID));
            }
            return list;
        }

        private object GetListItemFieldValue(SPListItem listItem, string fieldInternalName)
        {
            SPField field = listItem.ParentList.Fields.GetFieldByInternalName(fieldInternalName);
            return listItem[field.Id];
        }

    }
}
