<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="RDLCREPORTMVC.Reporting.ReportViewer" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .reportViewerStyle
        {
            background-color:white;
            width:100%;
            height:100%;
            min-height:500px;
            border:none;
        }
    </style>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
    <div>
        <%--<rsweb:ReportViewer CssClass="reportViewerStyle" SizeToReportContent="true" ID="rptViewer" runat="server"></rsweb:ReportViewer>--%>
    </div>
    </form>
</body>
</html>

