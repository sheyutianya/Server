echo on
protoc --descriptor_set_out=ProtoMyRequest.protobin --include_imports ProtoMyRequest.proto
protoc --descriptor_set_out=ProtoMyResponse.protobin --include_imports ProtoMyResponse.proto
protoc --descriptor_set_out=ProtoMyData.protobin --include_imports ProtoMyData.proto

protogen ProtoMyRequest.protobin
protogen ProtoMyResponse.protobin
protogen ProtoMyData.protobin