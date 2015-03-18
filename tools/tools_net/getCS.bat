echo on
protogen -i:ProtoMyRequest.proto -o:ProtoMyRequest.cs
protogen -i:ProtoMyResponse.proto -o:ProtoMyResponse.cs
protogen -i:ProtoMyData.proto -o:ProtoMyData.cs
protogen -i:OnlyTestMsg.proto -o:TestMsg.cs