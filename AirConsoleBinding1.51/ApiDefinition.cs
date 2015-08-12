// Binding for AirConsole iOS SDK V1.51
// Bill Fulton 1 May 2015

using System;
using CoreBluetooth;
using Foundation;
using ObjCRuntime;

namespace AirConsole.iOS
{
    // @interface AirconsoleDevice : NSObject
    [BaseType(typeof(NSObject))]
    interface AirconsoleDevice
    {
        // @property (readonly, nonatomic) NSString * name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) transport_t transport;
        [Export("transport")]
        transport_t Transport { get; }

        // @property (readonly, nonatomic) NSString * ipAddress;
        [Export("ipAddress")]
        string IpAddress { get; }

        // @property (readonly, nonatomic) int port;
        [Export("port")]
        int Port { get; }

        // @property (readonly, nonatomic) CBPeripheral * blePeripheral;
        [Export("blePeripheral")]
        CBPeripheral BlePeripheral { get; }

        // @property (readonly, nonatomic) NSString * deviceType;
        [Export("deviceType")]
        string DeviceType { get; }

        // @property (readonly, nonatomic) NSString * firmwareVersion;
        [Export("firmwareVersion")]
        string FirmwareVersion { get; }

        // @property (readonly, nonatomic) int portCount;
        [Export("portCount")]
        int PortCount { get; }

        // -(NSString *)portName:(int)portNumber;
        [Export("portName:")]
        string PortName(int portNumber);
    }

    // @protocol AirconsoleSessionDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AirconsoleSessionDelegate
    {
        // @optional -(void)sessionWillConnect:(id)session;
        [Export("sessionWillConnect:")]
        void SessionWillConnect(AirconsoleSession session);

        // @optional -(void)sessionDidConnect:(id)session;
        [Export("sessionDidConnect:")]
        void SessionDidConnect(AirconsoleSession session);

        // @optional -(void)sessionFailedToConnect:(id)session errorMessage:(NSString *)errorMessage;
        [Export("sessionFailedToConnect:errorMessage:")]
        void SessionFailedToConnect(AirconsoleSession session, string errorMessage);

        // @optional -(void)sessionDidDisconnect:(id)session;
        [Export("sessionDidDisconnect:")]
        void SessionDidDisconnect(AirconsoleSession session);

        // @optional -(void)sessionBytesAvailable:(id)session count:(NSUInteger)count;
        [Export("sessionBytesAvailable:count:")]
        void SessionBytesAvailable(AirconsoleSession session, int count);

        // @optional -(void)sessionDidOverflow:(id)session;
        [Export("sessionDidOverflow:")]
        void SessionDidOverflow(AirconsoleSession session);

        // @optional -(void)sessionLinePropertiesChanged:(id)session;
        [Export("sessionLinePropertiesChanged:")]
        void SessionLinePropertiesChanged(AirconsoleSession session);

        // @optional -(void)sessionModemStatusChanged:(id)session;
        [Export("sessionModemStatusChanged:")]
        void SessionModemStatusChanged(AirconsoleSession session);
    }

    // @interface AirconsoleSession : NSObject
    [BaseType(typeof(NSObject))]
    interface AirconsoleSession
    {
        // @property (readonly, nonatomic) AirconsoleDevice * device;
        [Export("device")]
        AirconsoleDevice Device { get; }

        // @property (readonly, nonatomic) int portNumber;
        [Export("portNumber")]
        int PortNumber { get; }

        // @property (readonly, nonatomic) BOOL connected;
        [Export("connected")]
        bool Connected { get; }

        // @property (readonly, nonatomic) BOOL connecting;
        [Export("connecting")]
        bool Connecting { get; }

        // @property (readonly, nonatomic) int rxByteCount;
        [Export("rxByteCount")]
        int RxByteCount { get; }

        // @property (readonly, nonatomic) int txByteCount;
        [Export("txByteCount")]
        int TxByteCount { get; }

        [Wrap("WeakDelegate")]
        AirconsoleSessionDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<AirconsoleSessionDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) int BaudRate;
        [Export("BaudRate")]
        int BaudRate { get; }

        // @property (readonly, nonatomic) databits_t DataBits;
        [Export("DataBits")]
        databits_t DataBits { get; }

        // @property (readonly, nonatomic) parity_t Parity;
        [Export("Parity")]
        parity_t Parity { get; }

        // @property (readonly, nonatomic) stopbits_t StopBits;
        [Export("StopBits")]
        stopbits_t StopBits { get; }

        // @property (readonly, nonatomic) flowcontrol_t FlowControl;
        [Export("FlowControl")]
        flowcontrol_t FlowControl { get; }

        // @property (readonly, nonatomic) BOOL DTR;
        [Export("DTR")]
        bool DTR { get; }

        // @property (readonly, nonatomic) BOOL RTS;
        [Export("RTS")]
        bool RTS { get; }

        // @property (readonly, nonatomic) unsigned char MSR;
        [Export("MSR")]
        byte MSR { get; }

        // @property (readonly, nonatomic) unsigned char PrevMSR;
        [Export("PrevMSR")]
        byte PrevMSR { get; }

        // @property (assign, nonatomic) BOOL keepaliveEnabled;
        [Export("keepaliveEnabled")]
        bool KeepaliveEnabled { get; set; }

        // @property (assign, nonatomic) NSTimeInterval keepaliveInterval;
        [Export("keepaliveInterval")]
        double KeepaliveInterval { get; set; }

        // @property (assign, nonatomic) NSTimeInterval keepaliveTimeout;
        [Export("keepaliveTimeout")]
        double KeepaliveTimeout { get; set; }

        // -(id)initWithDevice:(AirconsoleDevice *)device;
        [Export("initWithDevice:")]
        IntPtr Constructor(AirconsoleDevice device);

        // -(id)initWithDeviceAndPortNumber:(AirconsoleDevice *)device portNumber:(int)portNumber;
        [Export("initWithDeviceAndPortNumber:portNumber:")]
        IntPtr Constructor(AirconsoleDevice device, int portNumber);

        // -(BOOL)connect;
        [Export("connect")]
        //[Verify (MethodToProperty)]
		//bool Connect { get; }
		bool Connect();

        // -(BOOL)connectSync;
        [Export("connectSync")]
        //[Verify (MethodToProperty)]
		//bool ConnectSync { get; }
		bool ConnectSync();

        // -(void)disconnect;
        [Export("disconnect")]
        void Disconnect();

        // -(void)flush;
        [Export("flush")]
        void Flush();

        // -(NSUInteger)write:(const uint8_t *)buffer length:(NSUInteger)length;
        [Export("write:length:")]
        //unsafe nuint Write (byte* buffer, nuint length);
		nuint Write(IntPtr buffer, nuint length);

        // -(NSUInteger)read:(uint8_t *)buffer bufferLength:(NSUInteger)bufferLength;
        [Export("read:bufferLength:")]
        //unsafe nuint Read (byte* buffer, nuint bufferLength);
		nuint Read(IntPtr buffer, nuint bufferLength);

        // -(NSUInteger)bytesAvailable;
        [Export("bytesAvailable")]
        //[Verify (MethodToProperty)]
		//nuint BytesAvailable { get; }
		nuint BytesAvailable();

        // -(void)setLineParameters:(int)baudRate dataBits:(databits_t)dataBits parity:(parity_t)parity stopBits:(stopbits_t)stopBits;
        [Export("setLineParameters:dataBits:parity:stopBits:")]
        void SetLineParameters(int baudRate, databits_t dataBits, parity_t parity, stopbits_t stopBits);

        // -(void)setFlowControl:(flowcontrol_t)flowControl;
        [Export("setFlowControl:")]
        void SetFlowControl(flowcontrol_t flowControl);

        // -(void)sendBreak;
        [Export("sendBreak")]
        void SendBreak();

        // -(void)setDTR:(BOOL)enabled;
        [Export("setDTR:")]
        void SetDTR(bool enabled);

        // -(void)setRTS:(BOOL)enabled;
        [Export("setRTS:")]
        void SetRTS(bool enabled);
    }

    // @protocol AirconsoleMgrDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AirconsoleMgrDelegate
    {
        // @required -(void)deviceAdded:(AirconsoleDevice *)device;
        [Abstract]
        [Export("deviceAdded:")]
        void DeviceAdded(AirconsoleDevice device);

        // @required -(void)deviceRemoved:(AirconsoleDevice *)device;
        [Abstract]
        [Export("deviceRemoved:")]
        void DeviceRemoved(AirconsoleDevice device);
    }

    // @interface AirconsoleMgr : NSObject
    [BaseType(typeof(NSObject))]
    interface AirconsoleMgr
    {
        // @property (readonly, nonatomic) NSString * SDKVersion;
        [Export("SDKVersion")]
        string SDKVersion { get; }

        [Wrap("WeakDelegate")]
        AirconsoleMgrDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<AirconsoleMgrDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readwrite, nonatomic) BOOL scanWiFi;
        [Export("scanWiFi")]
        bool ScanWiFi { get; set; }

        // @property (readwrite, nonatomic) BOOL scanBluetooth;
        [Export("scanBluetooth")]
        bool ScanBluetooth { get; set; }

        // @property (readwrite, nonatomic) BOOL disableBluetoothWarning;
        [Export("disableBluetoothWarning")]
        bool DisableBluetoothWarning { get; set; }

        // -(void)scanForDevices;
        [Export("scanForDevices")]
        void ScanForDevices();

        // -(void)stopScanning;
        [Export("stopScanning")]
        void StopScanning();

        // -(AirconsoleDevice *)defaultDevice;
        [Export("defaultDevice")]
        //[Verify (MethodToProperty)]
		//AirconsoleDevice DefaultDevice { get; }
		AirconsoleDevice DefaultDevice();

        // -(NSArray *)deviceList;
        [Export("deviceList")]
        //[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		//NSObject[] DeviceList { get; }
		AirconsoleDevice[] DeviceList();

        // -(NSArray *)deviceListOfType:(transport_t)transport;
        [Export("deviceListOfType:")]
        //[Verify (StronglyTypedNSArray)]
		//NSObject[] DeviceListOfType (transport_t transport);
		AirconsoleDevice[] DeviceListOfType(transport_t transport);
    }
}
