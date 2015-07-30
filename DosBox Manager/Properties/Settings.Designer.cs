// Decompiled with JetBrains decompiler
// Type: DosBox_Manager.Properties.Settings
// Assembly: DosBox Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 63C1AFEC-4431-436C-926B-9B48CB6A22A7
// Assembly location: G:\Development\_Progetti Personali_\DosBox Manager\DosBox Manager\bin\Debug\DosBox Manager.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace DosBox_Manager.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings settings = Settings.defaultInstance;
        return settings;
      }
    }
  }
}
