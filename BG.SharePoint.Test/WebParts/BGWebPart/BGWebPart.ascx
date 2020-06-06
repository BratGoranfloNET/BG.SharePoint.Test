<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BGWebPart.ascx.cs" Inherits="BG.SharePoint.Test.WebParts.BGWebPart.BGWebPart" %>

<SharePoint:ScriptLink Language="javascript" Name="/_layouts/15/BG.SharePoint.Test/JS/modal-dialog.js" OnDemand="false" runat="server" Localizable="false" />

<div>
    <input id="test-input"/>
</div>
<br />
<div>
    <button type="button" id="test-button" onclick="testcall()">Жми! Тест</button>
</div>
<label id="test-result"></label>
<br />

<div>
    <button type="button" id="create-button" onclick="showDialog()">Создать записи!</button>   
</div>

 <div style="display:none">

        <div id="modal-dialog">
        
            <table>
                <tr>
                    <td>
                        <label>Наименование</label>
                    </td> 
                    <td>
                        <input id="naim" type="text" required>
                        <p style="color:red" id="naim-message"></p>
                    </td> 
                </tr>

                <tr>
                    <td>
                        <label>Номер начальный</label>
                    </td> 
                    <td>
                        <input id="firstnumber" type="number" min="1" required> 
                        <p style="color:red" id="firstnumber-message"></p>
                    </td> 
                </tr>

                <tr>
                    <td>
                        <label>Номер конечный</label>
                    </td> 
                    <td>
                        <input id="lastnumber" type="number" min="1"  required>
                        <p style="color:red" id="lastnumber-message"></p>
                    </td> 
                </tr>

                <tr>
                    <td>
                        <label>Цвет</label>
                    </td> 
                    <td>
                        <select id="test-color" name="color">
                        </select>
                    </td> 
                    <td>
                        <input id="newcolor" type="text">   
                    </td> 
                    <td>
                         <button onclick="createNewColor()">Новый цвет</button>  
                    </td> 
                </tr>

            </table>             
            
            <button onclick="createListItem()">Записать</button>
            <button>Отменить</button>
            
            </div>
     
 </div>