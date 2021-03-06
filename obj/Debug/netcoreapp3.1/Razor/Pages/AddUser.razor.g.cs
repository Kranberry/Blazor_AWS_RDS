#pragma checksum "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce975b38a89e7606f11ec6622caaf4484b626427"
// <auto-generated/>
#pragma warning disable 1591
namespace AWS_RDS_Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using AWS_RDS_Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using AWS_RDS_Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\C#_Projects\AWS_RDS_Blazor\_Imports.razor"
using AWS_RDS_Blazor.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddUser")]
    public partial class AddUser : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link href=\"css/AddUser.css\" rel=\"stylesheet\">\r\n\r\n");
            __builder.AddMarkupContent(1, "<h1>Add a user here yooo!</h1>\r\n\r\n");
            __builder.OpenElement(2, "form");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "placeholder", "FirstName");
            __builder.AddAttribute(5, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 8 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
                  firstName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => firstName = __value, firstName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n    ");
            __builder.OpenElement(8, "input");
            __builder.AddAttribute(9, "placeholder", "LastName");
            __builder.AddAttribute(10, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 9 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
                  lastName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => lastName = __value, lastName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.OpenElement(13, "input");
            __builder.AddAttribute(14, "placeholder", "R2D2@Star-trek.com");
            __builder.AddAttribute(15, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
                  email

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => email = __value, email));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n    ");
            __builder.OpenElement(18, "button");
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
                      (() => CreateUser())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventPreventDefaultAttribute(20, "onclick", 
#nullable restore
#line 11 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
                                                                     true

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(21, "Create User");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 14 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
 if (errorCreatingUser)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(22, "<h3 style=\"color: red;\">Things are entered wrong duud</h3>");
#nullable restore
#line 17 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
}
else if (createdSuccessful)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(23, "<h3 style=\"color: greenyellow;\">User created successfully</h3>");
#nullable restore
#line 21 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "D:\C#_Projects\AWS_RDS_Blazor\Pages\AddUser.razor"
       
    // Create the instance of the database handler class
    DbHandlerPostgresSQL db = new DbHandlerPostgresSQL();

    bool createdSuccessful = false;
    bool errorCreatingUser = false;

    string firstName = "";
    string lastName = "";
    string email = "";

    private bool UserCreationSuccessful()
    {
        // Do some bad checking to see if the fields are all filled in
        if(firstName.Length < 3 || lastName.Length < 3 || email.Length < 6)
        {
            errorCreatingUser = true;
            createdSuccessful = false;
            return false;
        }
        errorCreatingUser = false;
        createdSuccessful = true;
        return true;
    }

    void CreateUser()
    {
        if (!UserCreationSuccessful())
            return;

        User user = new User(firstName, lastName, email);
        Console.WriteLine(db.Insert("Users", new string[] { "FirstName", "LastName", "email" }, new string[] { firstName, lastName, email }));
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
