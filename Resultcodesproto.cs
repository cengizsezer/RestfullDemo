// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: resultcodesproto.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from resultcodesproto.proto</summary>
public static partial class ResultcodesprotoReflection {

  #region Descriptor
  /// <summary>File descriptor for resultcodesproto.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ResultcodesprotoReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChZyZXN1bHRjb2Rlc3Byb3RvLnByb3RvKkcKC1Jlc3VsdENvZGVzEggKBE5P",
          "TkUQABIOCgpTVUNDRVNTRlVMEAESCgoGRkFJTEVEEAISEgoOQUxSRUFEWV9F",
          "WElTVFMQA2IGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(new[] {typeof(global::ResultCodes), }, null, null));
  }
  #endregion

}
#region Enums
public enum ResultCodes {
  [pbr::OriginalName("NONE")] None = 0,
  [pbr::OriginalName("SUCCESSFUL")] Successful = 1,
  [pbr::OriginalName("FAILED")] Failed = 2,
  [pbr::OriginalName("ALREADY_EXISTS")] AlreadyExists = 3,
}

#endregion


#endregion Designer generated code