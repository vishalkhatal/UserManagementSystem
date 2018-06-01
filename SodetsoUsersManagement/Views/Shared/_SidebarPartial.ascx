<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<section class="sidebar">
    <!-- Sidebar user panel -->
    <div class="user-panel">
        <div class="pull-left image">
            <img src="../../Content/img/avatar3.png" class="img-circle" alt="User Image" />
        </div>
        <div class="pull-left info">
            <p><%: Session["Firstname"] %></p>

            <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
        </div>
    </div>

    <!-- sidebar menu: : style can be found in sidebar.less -->
    <ul class="sidebar-menu">
        <li class="active">
            <a href="/Home/Index">
                <i class="fa fa-dashboard"></i><span>Dashboard</span>
            </a>
        </li>
        <li class="treeview">
            <a href="#">
                <i class="fa fa-users"></i>
                <span>Users Management</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/UsersManagement/AddUser"><i class="fa fa-angle-double-right"></i>Add User</a></li>
                <li><a href="/UsersManagement/UsersList"><i class="fa fa-angle-double-right"></i>Users List</a></li>
                <li><a href="/UsersManagement/ActiveUsers"><i class="fa fa-angle-double-right"></i>Active Users</a></li>
                <li><a href="/UsersManagement/InactiveUsers"><i class="fa fa-angle-double-right"></i>Inactive Users</a></li>
                <li><a href="/UsersManagement/ArchivedUsers"><i class="fa fa-angle-double-right"></i>Archived Users</a></li>
            </ul>
        </li>
        <li>
            <a href="/Home/SignOut">
                <i class="fa fa-power-off"></i><span>Logout</span>
            </a>
        </li>
       
    </ul>
</section>
