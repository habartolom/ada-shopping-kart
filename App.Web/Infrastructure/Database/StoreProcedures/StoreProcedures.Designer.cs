﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Web.Infrastructure.Database.StoreProcedures {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class StoreProcedures {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StoreProcedures() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("App.Web.Infrastructure.Database.StoreProcedures.StoreProcedures", typeof(StoreProcedures).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N&apos;AddProductToOrder&apos; AND type = &apos;P&apos;)
        ///BEGIN
        ///	EXEC dbo.sp_executesql @statement = N&apos;CREATE PROCEDURE [dbo].[AddProductToOrder] AS&apos;
        ///END
        ///
        ///EXEC dbo.sp_executesql @statement = 
        ///N&apos;
        ///-- =============================================
        ///-- Author:		Harold Bartolo
        ///-- Create date: Aug 2, 2023
        ///-- Description:	Add Product To Order
        ///-- =============================================
        ///
        ///ALTER   PROCEDURE [dbo].[AddProductToOrder] 
        ///	@id UNIQUEIDENTIFIER,
        ///    @price [rest of string was truncated]&quot;;.
        /// </summary>
        public static string BulkInsertOrderProducts {
            get {
                return ResourceManager.GetString("BulkInsertOrderProducts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N&apos;CreateOrder&apos; AND type = &apos;P&apos;)
        ///BEGIN
        ///	EXEC dbo.sp_executesql @statement = N&apos;CREATE PROCEDURE [dbo].[CreateOrder] AS&apos;
        ///END
        ///
        ///EXEC dbo.sp_executesql @statement = 
        ///N&apos;
        ///-- =============================================
        ///-- Author:		Harold Bartolo
        ///-- Create date: Aug 2, 2023
        ///-- Description:	Insert Order
        ///-- =============================================
        ///
        ///ALTER   PROCEDURE [dbo].[CreateOrder] 
        ///	@id UNIQUEIDENTIFIER,
        ///    @userId UNIQUEIDENTIFIER,
        ///    @ [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateOrder {
            get {
                return ResourceManager.GetString("CreateOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = N&apos;AddProductToOrder&apos; AND type = &apos;P&apos;)
        ///BEGIN
        ///	EXEC dbo.sp_executesql @statement = N&apos;CREATE PROCEDURE [dbo].[AddProductToOrder] AS&apos;
        ///END
        ///
        ///EXEC dbo.sp_executesql @statement = 
        ///N&apos;
        ///-- =============================================
        ///-- Author:		Harold Bartolo
        ///-- Create date: Aug 2, 2023
        ///-- Description:	Add Product To Order
        ///-- =============================================
        ///
        ///ALTER   PROCEDURE [dbo].[AddProductToOrder] 
        ///	@id UNIQUEIDENTIFIER,
        ///    @price [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateOrderProductsType {
            get {
                return ResourceManager.GetString("CreateOrderProductsType", resourceCulture);
            }
        }
    }
}