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
public partial class Model {
    
    private string nameField;
    
    private ModelBone[] bonesField;
    
    private ModelVertex[] verticesField;
    
    private ModelView viewField;
    
    private ModelTexture[] texturesField;
    
    private int[] blendingField;
    
    private ModelAttachment[] attachmentsField;
    
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
    [System.Xml.Serialization.XmlArrayItemAttribute("Bone", IsNullable=false)]
    public ModelBone[] Bones {
        get {
            return this.bonesField;
        }
        set {
            this.bonesField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Vertex", IsNullable=false)]
    public ModelVertex[] Vertices {
        get {
            return this.verticesField;
        }
        set {
            this.verticesField = value;
        }
    }
    
    /// <uwagi/>
    public ModelView View {
        get {
            return this.viewField;
        }
        set {
            this.viewField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Texture", IsNullable=false)]
    public ModelTexture[] Textures {
        get {
            return this.texturesField;
        }
        set {
            this.texturesField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Blend", IsNullable=false)]
    public int[] Blending {
        get {
            return this.blendingField;
        }
        set {
            this.blendingField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Attachment", IsNullable=false)]
    public ModelAttachment[] Attachments {
        get {
            return this.attachmentsField;
        }
        set {
            this.attachmentsField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelBone {
    
    private int billboardField;
    
    private int parentField;
    
    private ModelBoneTranslation translationField;
    
    private ModelBoneRotation rotationField;
    
    private ModelBoneScale scaleField;
    
    private ModelBonePosition positionField;
    
    /// <uwagi/>
    public int Billboard {
        get {
            return this.billboardField;
        }
        set {
            this.billboardField = value;
        }
    }
    
    /// <uwagi/>
    public int Parent {
        get {
            return this.parentField;
        }
        set {
            this.parentField = value;
        }
    }
    
    /// <uwagi/>
    public ModelBoneTranslation Translation {
        get {
            return this.translationField;
        }
        set {
            this.translationField = value;
        }
    }
    
    /// <uwagi/>
    public ModelBoneRotation Rotation {
        get {
            return this.rotationField;
        }
        set {
            this.rotationField = value;
        }
    }
    
    /// <uwagi/>
    public ModelBoneScale Scale {
        get {
            return this.scaleField;
        }
        set {
            this.scaleField = value;
        }
    }
    
    /// <uwagi/>
    public ModelBonePosition Position {
        get {
            return this.positionField;
        }
        set {
            this.positionField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelBoneTranslation {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelBoneRotation {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private float wField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float w {
        get {
            return this.wField;
        }
        set {
            this.wField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelBoneScale {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelBonePosition {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelVertex {
    
    private ModelVertexPosition positionField;
    
    private ModelVertexBone[] bonesField;
    
    private ModelVertexNormal normalField;
    
    private ModelVertexTexture textureField;
    
    /// <uwagi/>
    public ModelVertexPosition Position {
        get {
            return this.positionField;
        }
        set {
            this.positionField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Bone", IsNullable=false)]
    public ModelVertexBone[] Bones {
        get {
            return this.bonesField;
        }
        set {
            this.bonesField = value;
        }
    }
    
    /// <uwagi/>
    public ModelVertexNormal Normal {
        get {
            return this.normalField;
        }
        set {
            this.normalField = value;
        }
    }
    
    /// <uwagi/>
    public ModelVertexTexture Texture {
        get {
            return this.textureField;
        }
        set {
            this.textureField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelVertexPosition {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelVertexBone {
    
    private int indexField;
    
    private int weightField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int index {
        get {
            return this.indexField;
        }
        set {
            this.indexField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int weight {
        get {
            return this.weightField;
        }
        set {
            this.weightField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelVertexNormal {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelVertexTexture {
    
    private float xField;
    
    private float yField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelView {
    
    private int[] indicesField;
    
    private int[] trianglesField;
    
    private ModelViewGeoset[] geosetsField;
    
    private ModelViewTexture[] texturesField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Index", IsNullable=false)]
    public int[] Indices {
        get {
            return this.indicesField;
        }
        set {
            this.indicesField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Triangle", IsNullable=false)]
    public int[] Triangles {
        get {
            return this.trianglesField;
        }
        set {
            this.trianglesField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Geoset", IsNullable=false)]
    public ModelViewGeoset[] Geosets {
        get {
            return this.geosetsField;
        }
        set {
            this.geosetsField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Texture", IsNullable=false)]
    public ModelViewTexture[] Textures {
        get {
            return this.texturesField;
        }
        set {
            this.texturesField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelViewGeoset {
    
    private int triangleField;
    
    private int trianglesField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int triangle {
        get {
            return this.triangleField;
        }
        set {
            this.triangleField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int triangles {
        get {
            return this.trianglesField;
        }
        set {
            this.trianglesField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelViewTexture {
    
    private int geosetField;
    
    private int blendField;
    
    private int textureField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int geoset {
        get {
            return this.geosetField;
        }
        set {
            this.geosetField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int blend {
        get {
            return this.blendField;
        }
        set {
            this.blendField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int texture {
        get {
            return this.textureField;
        }
        set {
            this.textureField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelTexture {
    
    private int typeField;
    
    private string fileField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string file {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelAttachment {
    
    private int idField;
    
    private int boneField;
    
    private ModelAttachmentPosition positionField;
    
    /// <uwagi/>
    public int ID {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <uwagi/>
    public int Bone {
        get {
            return this.boneField;
        }
        set {
            this.boneField = value;
        }
    }
    
    /// <uwagi/>
    public ModelAttachmentPosition Position {
        get {
            return this.positionField;
        }
        set {
            this.positionField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ModelAttachmentPosition {
    
    private float xField;
    
    private float yField;
    
    private float zField;
    
    private string valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}
