﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Items {
    
    private ItemsItem[] itemField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("Item")]
    public ItemsItem[] Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemsItem {
    
    private string idField;
    
    private string nameField;
    
    private string typeField;
    
    private string slotField;
    
    private int qualityField;
    
    private string iconField;
    
    private ItemsItemModels modelsField;
    
    private ItemsItemTextures texturesField;
    
    private int allowableClassField;
    
    private int allowableRaceField;
    
    private int maxCountField;
    
    /// <uwagi/>
    public string ID {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <uwagi/>
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <uwagi/>
    public string Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <uwagi/>
    public string Slot {
        get {
            return this.slotField;
        }
        set {
            this.slotField = value;
        }
    }
    
    /// <uwagi/>
    public int Quality {
        get {
            return this.qualityField;
        }
        set {
            this.qualityField = value;
        }
    }
    
    /// <uwagi/>
    public string Icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <uwagi/>
    public ItemsItemModels Models {
        get {
            return this.modelsField;
        }
        set {
            this.modelsField = value;
        }
    }
    
    /// <uwagi/>
    public ItemsItemTextures Textures {
        get {
            return this.texturesField;
        }
        set {
            this.texturesField = value;
        }
    }
    
    /// <uwagi/>
    public int AllowableClass {
        get {
            return this.allowableClassField;
        }
        set {
            this.allowableClassField = value;
        }
    }
    
    /// <uwagi/>
    public int AllowableRace {
        get {
            return this.allowableRaceField;
        }
        set {
            this.allowableRaceField = value;
        }
    }
    
    /// <uwagi/>
    public int MaxCount {
        get {
            return this.maxCountField;
        }
        set {
            this.maxCountField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemsItemModels {
    
    private string leftField;
    
    private string rightField;
    
    private string capeField;
    
    private string sleeveField;
    
    private string doubletField;
    
    private string robeField;
    
    /// <uwagi/>
    public string Left {
        get {
            return this.leftField;
        }
        set {
            this.leftField = value;
        }
    }
    
    /// <uwagi/>
    public string Right {
        get {
            return this.rightField;
        }
        set {
            this.rightField = value;
        }
    }
    
    /// <uwagi/>
    public string Cape {
        get {
            return this.capeField;
        }
        set {
            this.capeField = value;
        }
    }
    
    /// <uwagi/>
    public string Sleeve {
        get {
            return this.sleeveField;
        }
        set {
            this.sleeveField = value;
        }
    }
    
    /// <uwagi/>
    public string Doublet {
        get {
            return this.doubletField;
        }
        set {
            this.doubletField = value;
        }
    }
    
    /// <uwagi/>
    public string Robe {
        get {
            return this.robeField;
        }
        set {
            this.robeField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemsItemTextures {
    
    private string leftField;
    
    private string rightField;
    
    private string armUpperField;
    
    private string armLowerField;
    
    private string handField;
    
    private string torsoUpperField;
    
    private string torsoLowerField;
    
    private string legUpperField;
    
    private string legLowerField;
    
    private string footField;
    
    /// <uwagi/>
    public string Left {
        get {
            return this.leftField;
        }
        set {
            this.leftField = value;
        }
    }
    
    /// <uwagi/>
    public string Right {
        get {
            return this.rightField;
        }
        set {
            this.rightField = value;
        }
    }
    
    /// <uwagi/>
    public string ArmUpper {
        get {
            return this.armUpperField;
        }
        set {
            this.armUpperField = value;
        }
    }
    
    /// <uwagi/>
    public string ArmLower {
        get {
            return this.armLowerField;
        }
        set {
            this.armLowerField = value;
        }
    }
    
    /// <uwagi/>
    public string Hand {
        get {
            return this.handField;
        }
        set {
            this.handField = value;
        }
    }
    
    /// <uwagi/>
    public string TorsoUpper {
        get {
            return this.torsoUpperField;
        }
        set {
            this.torsoUpperField = value;
        }
    }
    
    /// <uwagi/>
    public string TorsoLower {
        get {
            return this.torsoLowerField;
        }
        set {
            this.torsoLowerField = value;
        }
    }
    
    /// <uwagi/>
    public string LegUpper {
        get {
            return this.legUpperField;
        }
        set {
            this.legUpperField = value;
        }
    }
    
    /// <uwagi/>
    public string LegLower {
        get {
            return this.legLowerField;
        }
        set {
            this.legLowerField = value;
        }
    }
    
    /// <uwagi/>
    public string Foot {
        get {
            return this.footField;
        }
        set {
            this.footField = value;
        }
    }
}
