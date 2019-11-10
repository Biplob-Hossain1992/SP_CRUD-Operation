<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfoForm.aspx.cs" Inherits="StudentInformationWebForm.StudentInfoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Section: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="sectionDropDownList" runat="server" Width="208px">
            </asp:DropDownList>
            <%--<asp:SqlDataSource ID="HomeTask" runat="server" ConnectionString="<%$ ConnectionStrings:HomeTaskConnectionString %>" SelectCommand="SELECT [SectionName] FROM [Section]"></asp:SqlDataSource>--%>
            <br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Student ID: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="idTextBox" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nameTextBox" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Father's Name: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="fatherNameTextBox" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Mother's Name: "></asp:Label>
&nbsp;
            <asp:TextBox ID="motherNameTextBox" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Phone No: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="phoneNoTextBox" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="searchIdTextBox" runat="server" Width="300px"></asp:TextBox>
&nbsp;<asp:Button ID="findButton" runat="server" Font-Bold="True" Text="Find By ID" OnClick="findButton_Click" />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="saveButton" runat="server" Text="Save" Width="64px" OnClick="saveButton_Click" />
            <asp:Button ID="updateButton" runat="server" Text="Update" Width="64px" OnClick="updateButton_Click" />
            <asp:Button ID="deleteButton" runat="server" Text="Delete" Width="64px" OnClick="deleteButton_Click" />
            <asp:Button ID="newButton" runat="server" Text="New" Width="64px" OnClick="newButton_Click" />
            <asp:Button ID="printButton" runat="server" Font-Bold="True" Text="Print" Width="64px" OnClick="printButton_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="showAllStudentGridView" runat="server" OnSelectedIndexChanged="showAllStudentGridView_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="#CCCCCC">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Select" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="StudentId" HeaderText="Student ID" />
                    <asp:BoundField DataField="Name" HeaderText="Student Name" />
                    <asp:BoundField DataField="FatherName" HeaderText="Father's Name" />
                    <asp:BoundField DataField="MotherName" HeaderText="Mother's Name" />
                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
