//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Merp.Web.Auth.Resources.Manage {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Profile {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Profile() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Merp.Web.Auth.Resources.Manage.Profile", typeof(Profile).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phone.
        /// </summary>
        internal static string PhoneNumber {
            get {
                return ResourceManager.GetString("PhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to My account.
        /// </summary>
        internal static string ProfilePageTitle {
            get {
                return ResourceManager.GetString("ProfilePageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User profile saved successfully!.
        /// </summary>
        internal static string ProfileSavedSuccessfully {
            get {
                return ResourceManager.GetString("ProfileSavedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Send verification email.
        /// </summary>
        internal static string SendVerificationEmail {
            get {
                return ResourceManager.GetString("SendVerificationEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Verification email sent successfully!.
        /// </summary>
        internal static string VerificationEmailSent {
            get {
                return ResourceManager.GetString("VerificationEmailSent", resourceCulture);
            }
        }
    }
}
