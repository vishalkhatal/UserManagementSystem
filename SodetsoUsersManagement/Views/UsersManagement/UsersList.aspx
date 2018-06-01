﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SodetsoUsersManagement.Models.UsersListModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ViewBag.PageTitle = "Users List" %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- row -->
    <div class="row">
        <div class="col-md-6">
            <% if (TempData["Success"] != null)
               { %>
            <div class="alert alert-success alert-dismissable">
                <i class="fa fa-check"></i>
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <b>Alert!</b> Success.
       
            </div>
            <% } %>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12">
            <div class="box box-primary">

                <!-- /.box-header -->
                <div class="box-body table-responsive">
                    <table id="example1" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Image</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Position</th>
                                <th>Phone</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in Model)
                               {%>
                            <tr>
                                <td>
                                    <% if (item.Image == null)
                                       { %>
                                    <img src="../../assets/img/avatar.png" alt="<%: @Html.DisplayFor(m => item.Firstname) %>" height="70" width="70" />

                                    <%}
                                       else
                                       { %>

                                    <%      
                                           {
                                               var base64 = Convert.ToBase64String(item.Image);
                                               var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                                    %>

                                    <img src="<%: @imgSrc %>" alt="<%: @Html.DisplayFor(m => item.Firstname) %>" height="70" width="70" /><%} %>
                                    <%} %>
                                </td>

                                <td><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></td>
                                <td><%: Html.DisplayFor(m => item.Gender) %></td>
                                <td><%: Html.DisplayFor(m => item.Position) %></td>
                                <td><%: Html.DisplayFor(m => item.Phone) %></td>
                                <td>
                                    <% if (item.IsActive == 1) 
                                    { %>                                    
                                        <%--<span class="label label-primary">Active</span>--%>

                                        <a href="#DeactivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" data-toggle="modal"><span class="label label-success">Active</span></a>
                                        
                                        <!-- Deactvate User Modal -->
                                        <div class="modal fade" id="DeactivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                        <h4 class="modal-title"> Deactivate User</h4>
                                                    </div>
                                                    <% using (Html.BeginForm("DeactivateActivateUser", null, FormMethod.Post, new { @class = "smart-form client-form", role = "form", id = "smart-form-register", enctype = "multipart/form-data" }))
                                                    { %>
                                                        <div class="modal-body">
                                                           Are you sure you want to deactivate the User <strong><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></strong>?
                                                           
                                                            <input type="hidden" class="form-control" name="UserID" value="<%: Html.DisplayFor(m => item.UserID) %>" />
                                                           <input type="hidden" name="Operation" value="Deactivate" />
                                                        </div>
                                                        <div class="modal-footer clearfix"> 
                                                             <button type="submit" class="btn btn-primary"> Yes</button>                         
                                                             <button type="button" class="btn btn-danger" data-dismiss="modal"> Cancel</button> 
                                                        </div>
                                                    <% }%>
                                                </div><!-- /.modal-content -->
                                            </div><!-- /.modal-dialog -->
                                        </div>
                                        <!-- /.Disable User modal -->

                                    <% }
                                    else
                                    { %>
                                    <a href="#ActivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" data-toggle="modal"><span class="label label-warning">Inactive</span></a>

                                    <!-- Activate User Modal -->
                                    <div class="modal fade" id="ActivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title"> Activate User</h4>
                                                </div>
                                                <% using (Html.BeginForm("DeactivateActivateUser", null, FormMethod.Post, new { @class = "smart-form client-form", role = "form", id = "smart-form-register", enctype = "multipart/form-data" }))
                                                { %>
                                                    <div class="modal-body">
                                                        Are you sure you want to Activate the User <strong><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></strong>?
                                                           
                                                        <input type="hidden" class="form-control" name="UserID" value="<%: Html.DisplayFor(m => item.UserID) %>" />
                                                        <input type="hidden" name="Operation" value="Activate" />
                                                    </div>
                                                    <div class="modal-footer clearfix"> 
                                                            <button type="submit" class="btn btn-primary"> Yes</button>                         
                                                            <button type="button" class="btn btn-danger" data-dismiss="modal"> Cancel</button> 
                                                    </div>
                                                <% }%>
                                            </div><!-- /.modal-content -->
                                        </div><!-- /.modal-dialog -->
                                    </div>
                                    <!-- /.Activate User modal -->
                                    <% } %> 
                                </td>
                                <td>
                                    <a class="btn btn-xs btn-primary" href="/UsersManagement/EditUser/<%: Html.DisplayFor(m => item.UserID) %>"><i class="fa fa-edit"></i></a>
                                    <%--<button class="btn btn-xs btn-primary" type="button" data-toggle="modal" data-target="#EditUser<%: Html.DisplayFor(m => item.UserID) %>"><i class="fa fa-edit"></i></button>--%>
                                    <button class="btn btn-xs btn-danger" type="button" data-toggle="modal" data-target="#RemoveUser<%: Html.DisplayFor(m => item.UserID) %>"><i class="fa fa-times fa fa-white"></i></button>

                                    <!-- Remove User Modal -->
                                        <div class="modal fade" id="RemoveUser<%: Html.DisplayFor(m => item.UserID) %>" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                        <h4 class="modal-title"> Remove User</h4>
                                                    </div>
                                                    <% using (Html.BeginForm("RemoveUser", null, FormMethod.Post, new { @class = "smart-form client-form", role = "form", id = "smart-form-register"}))
                                                    { %>
                                                        <div class="modal-body">
                                                           Are you sure you want to remove the User <strong><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></strong>?
                                                           
                                                            <input type="hidden" class="form-control" name="UserID" value="<%: Html.DisplayFor(m => item.UserID) %>" />
                                                        </div>
                                                        <div class="modal-footer clearfix"> 
                                                             <button type="submit" class="btn btn-primary"> Yes</button>                         
                                                             <button type="button" class="btn btn-danger" data-dismiss="modal"> Cancel</button> 
                                                        </div>
                                                    <% }%>
                                                </div><!-- /.modal-content -->
                                            </div><!-- /.modal-dialog -->
                                        </div>
                                        <!-- /.Remove User modal -->
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>Image</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Position</th>
                                <th>Phone</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
    </div>
</asp:Content>
