// Code generated by protoc-gen-go. DO NOT EDIT.
// source: user.proto

package world

import (
	fmt "fmt"
	proto "github.com/golang/protobuf/proto"
	math "math"
)

// Reference imports to suppress errors if they are not otherwise used.
var _ = proto.Marshal
var _ = fmt.Errorf
var _ = math.Inf

// This is a compile-time assertion to ensure that this generated file
// is compatible with the proto package it is being compiled against.
// A compilation error at this line likely means your copy of the
// proto package needs to be updated.
const _ = proto.ProtoPackageIsVersion3 // please upgrade the proto package

type Transform_ struct {
	X                    float32  `protobuf:"fixed32,1,opt,name=x,proto3" json:"x,omitempty"`
	Y                    float32  `protobuf:"fixed32,2,opt,name=y,proto3" json:"y,omitempty"`
	Z                    float32  `protobuf:"fixed32,3,opt,name=z,proto3" json:"z,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *Transform_) Reset()         { *m = Transform_{} }
func (m *Transform_) String() string { return proto.CompactTextString(m) }
func (*Transform_) ProtoMessage()    {}
func (*Transform_) Descriptor() ([]byte, []int) {
	return fileDescriptor_116e343673f7ffaf, []int{0}
}

func (m *Transform_) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_Transform_.Unmarshal(m, b)
}
func (m *Transform_) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_Transform_.Marshal(b, m, deterministic)
}
func (m *Transform_) XXX_Merge(src proto.Message) {
	xxx_messageInfo_Transform_.Merge(m, src)
}
func (m *Transform_) XXX_Size() int {
	return xxx_messageInfo_Transform_.Size(m)
}
func (m *Transform_) XXX_DiscardUnknown() {
	xxx_messageInfo_Transform_.DiscardUnknown(m)
}

var xxx_messageInfo_Transform_ proto.InternalMessageInfo

func (m *Transform_) GetX() float32 {
	if m != nil {
		return m.X
	}
	return 0
}

func (m *Transform_) GetY() float32 {
	if m != nil {
		return m.Y
	}
	return 0
}

func (m *Transform_) GetZ() float32 {
	if m != nil {
		return m.Z
	}
	return 0
}

type Rotation_ struct {
	EulerX               float32  `protobuf:"fixed32,1,opt,name=eulerX,proto3" json:"eulerX,omitempty"`
	EulerY               float32  `protobuf:"fixed32,2,opt,name=eulerY,proto3" json:"eulerY,omitempty"`
	EulerZ               float32  `protobuf:"fixed32,3,opt,name=eulerZ,proto3" json:"eulerZ,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *Rotation_) Reset()         { *m = Rotation_{} }
func (m *Rotation_) String() string { return proto.CompactTextString(m) }
func (*Rotation_) ProtoMessage()    {}
func (*Rotation_) Descriptor() ([]byte, []int) {
	return fileDescriptor_116e343673f7ffaf, []int{1}
}

func (m *Rotation_) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_Rotation_.Unmarshal(m, b)
}
func (m *Rotation_) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_Rotation_.Marshal(b, m, deterministic)
}
func (m *Rotation_) XXX_Merge(src proto.Message) {
	xxx_messageInfo_Rotation_.Merge(m, src)
}
func (m *Rotation_) XXX_Size() int {
	return xxx_messageInfo_Rotation_.Size(m)
}
func (m *Rotation_) XXX_DiscardUnknown() {
	xxx_messageInfo_Rotation_.DiscardUnknown(m)
}

var xxx_messageInfo_Rotation_ proto.InternalMessageInfo

func (m *Rotation_) GetEulerX() float32 {
	if m != nil {
		return m.EulerX
	}
	return 0
}

func (m *Rotation_) GetEulerY() float32 {
	if m != nil {
		return m.EulerY
	}
	return 0
}

func (m *Rotation_) GetEulerZ() float32 {
	if m != nil {
		return m.EulerZ
	}
	return 0
}

type User struct {
	UserId               string      `protobuf:"bytes,1,opt,name=user_id,json=userId,proto3" json:"user_id,omitempty"`
	Transform            *Transform_ `protobuf:"bytes,2,opt,name=transform,proto3" json:"transform,omitempty"`
	Rotation             *Rotation_  `protobuf:"bytes,3,opt,name=rotation,proto3" json:"rotation,omitempty"`
	XXX_NoUnkeyedLiteral struct{}    `json:"-"`
	XXX_unrecognized     []byte      `json:"-"`
	XXX_sizecache        int32       `json:"-"`
}

func (m *User) Reset()         { *m = User{} }
func (m *User) String() string { return proto.CompactTextString(m) }
func (*User) ProtoMessage()    {}
func (*User) Descriptor() ([]byte, []int) {
	return fileDescriptor_116e343673f7ffaf, []int{2}
}

func (m *User) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_User.Unmarshal(m, b)
}
func (m *User) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_User.Marshal(b, m, deterministic)
}
func (m *User) XXX_Merge(src proto.Message) {
	xxx_messageInfo_User.Merge(m, src)
}
func (m *User) XXX_Size() int {
	return xxx_messageInfo_User.Size(m)
}
func (m *User) XXX_DiscardUnknown() {
	xxx_messageInfo_User.DiscardUnknown(m)
}

var xxx_messageInfo_User proto.InternalMessageInfo

func (m *User) GetUserId() string {
	if m != nil {
		return m.UserId
	}
	return ""
}

func (m *User) GetTransform() *Transform_ {
	if m != nil {
		return m.Transform
	}
	return nil
}

func (m *User) GetRotation() *Rotation_ {
	if m != nil {
		return m.Rotation
	}
	return nil
}

func init() {
	proto.RegisterType((*Transform_)(nil), "world.Transform_")
	proto.RegisterType((*Rotation_)(nil), "world.Rotation_")
	proto.RegisterType((*User)(nil), "world.User")
}

func init() { proto.RegisterFile("user.proto", fileDescriptor_116e343673f7ffaf) }

var fileDescriptor_116e343673f7ffaf = []byte{
	// 199 bytes of a gzipped FileDescriptorProto
	0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xff, 0xe2, 0xe2, 0x2a, 0x2d, 0x4e, 0x2d,
	0xd2, 0x2b, 0x28, 0xca, 0x2f, 0xc9, 0x17, 0x62, 0x2d, 0xcf, 0x2f, 0xca, 0x49, 0x51, 0x32, 0xe3,
	0xe2, 0x0a, 0x29, 0x4a, 0xcc, 0x2b, 0x4e, 0xcb, 0x2f, 0xca, 0x8d, 0x17, 0xe2, 0xe1, 0x62, 0xac,
	0x90, 0x60, 0x54, 0x60, 0xd4, 0x60, 0x0a, 0x62, 0xac, 0x00, 0xf1, 0x2a, 0x25, 0x98, 0x20, 0xbc,
	0x4a, 0x10, 0xaf, 0x4a, 0x82, 0x19, 0xc2, 0xab, 0x52, 0x0a, 0xe6, 0xe2, 0x0c, 0xca, 0x2f, 0x49,
	0x2c, 0xc9, 0xcc, 0xcf, 0x8b, 0x17, 0x12, 0xe3, 0x62, 0x4b, 0x2d, 0xcd, 0x49, 0x2d, 0x8a, 0x80,
	0xea, 0x85, 0xf2, 0xe0, 0xe2, 0x91, 0x50, 0x53, 0xa0, 0x3c, 0xb8, 0x78, 0x14, 0xd4, 0x3c, 0x28,
	0x4f, 0xa9, 0x8e, 0x8b, 0x25, 0xb4, 0x38, 0xb5, 0x48, 0x48, 0x9c, 0x8b, 0x1d, 0xe4, 0xd2, 0xf8,
	0xcc, 0x14, 0xb0, 0x81, 0x9c, 0x41, 0x6c, 0x20, 0xae, 0x67, 0x8a, 0x90, 0x3e, 0x17, 0x67, 0x09,
	0xcc, 0xb5, 0x60, 0x33, 0xb9, 0x8d, 0x04, 0xf5, 0xc0, 0x1e, 0xd1, 0x43, 0xf8, 0x22, 0x08, 0xa1,
	0x46, 0x48, 0x87, 0x8b, 0xa3, 0x08, 0xea, 0x4c, 0xb0, 0x5d, 0xdc, 0x46, 0x02, 0x50, 0xf5, 0x70,
	0xd7, 0x07, 0xc1, 0x55, 0x24, 0xb1, 0x81, 0x83, 0xc6, 0x18, 0x10, 0x00, 0x00, 0xff, 0xff, 0xce,
	0x3d, 0x45, 0xe1, 0x28, 0x01, 0x00, 0x00,
}