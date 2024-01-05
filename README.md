# Description
VaRA is Unity3D Game Structure for T.O.S. gaming - mostly inspired by several 18+ content on YouTube.

This game structure is designed to create games and toys that are targeted to adult entertainment industry.

# What is included in VaRA
VaRA consist of structure that allows for easy game creation - it contains basic scene with XR Rig that has several mechanics related to explicit gaming already attached. More mechanics will be implemented in future based on user feedback.

## Currently supported mechanics
### Blindfold
Blindfold is desgined to limit player's ability to see. You can choose color (32-bit RGBA) and state of blindfold (ON/OFF)

### Locks
Actually not locks, but intended to be used in such case - those are positional objects that are located in 3D world space designed to be used for distance calculations. 

Simply - ask API to move object to specific location and if player's controller is not here you can execute custom functions of your devices that will force player to move their controllers to that location.  

Currently three types of controllers are supported: left hand, right hand and head-mount-display.

# API Structure

API is used to set-up device/game properties like `HMD.POSITION`. Property can be either GET/SET or both at once.  

Property describes single settings that can be changed eg. color of object or its position.
Property Identifier is name used to call this property using external COM port.

API by default connects to `COM11`. This can be changed on 'Game' object in Core Scene. It's planned to implement a custom handshake to connect with target device without having to hard-specify COM port.

## Handshake protocol

Handshake protocol will be described here after implenentation.
```
[PLACEHOLDER]
```

## Usage
Commands / properties can be changed via COM port (this API is designed primarily to cooperate with external devices).

To set a property you need to call it's identifier followed by equals sign and value. Command ends with `CR/LF`.
Example:
```
BLINDFOLD.ACTIVE=TRUE
```

To get property value you need to call identifier followed by equals sign and question mark. Command ends with `CR/LF`
Example:
```
BLINDFOLD.ACTIVE=?
```

Command always need to end with `CR/LF`. Only one `=` sign in command is allowed (no equal signs in value).

## Responses
If you get a property the response will look like following:
```
[sent]: LEFT_HAND.POSITION=?
[recv]: LEFT_HAND.POSITION=<1.0, 1.2, 0.5>
```

When you set a property it will respond with `OK` or with an error eg.
```
[sent]: LEFT_HAND.POSITION=<1.0, 1.2, 0.5>
[recv]: ERROR=NOT_SUPPORTED

[sent]: LEFT_HAND.LOCK.TARGET.POSITION=<1.0, 1.2, 0.5>
[recv]: OK
```

### Error statuses
#### `UNKNOWN_COMMAND`
Command does not exist or was not registered
#### `INVALID_COMMAND`
Command is invalid - too many/few equals signs
#### `NOT_IMPLEMENTED`
Developer is lazy and this feature is not yet implemented
#### `NOT_SUPPORTED`
This feature is intentionally not supported.
#### `INVALID_VALUE`
Value was invalid (usually too many/few values for vector/color)

## Modules
Modules are designed to make people contribute easily without conflicts. Module naming convention mismatches will result in Pull Request denials (no mess is allowed).

It is designed to contain custom `Properties` and `Scenes` made by specific community member.

### Properties
To create custom property you need to extend `DeviceProperty` class and implement `ISettableDeviceProperty` or `IGettableDeviceProperty` (or both) interface(s).

Also you will need to register this property in DeviceObject instance (you can get one using `DeviceObject.Get()`)

### Scenes
You're allowed to create new scenes within your module. Remember to import Core Scene from `Assets/Scenes` to implement all basic mechanics. This allows for easy updates without having to reimport prefab into your scene (if it gets changed).

Your scene needs to contain `Room` script (this script object will define scene play area and can be moved using `CONFIG.ROOM.OFFSET` property to match real-world room - noone likes walking right into wall right?)

# Contribution
If you want to contribute to VaRA feel free to issue a Pull Request, however please follow naming and structuring conventions for this project (otherwise your PR probably will be rejected)

## Naming of Properties
Property should be as descriptive as possible - eg. `HMDPosition` for HMD position get property or `HMDLockPosition` for property regarding lock location. Try to keep it short, but descriptive. 

Pull request will most likely be accepted and naming will be updated if it's not clear.

## Property Identifiers
Property identifier should be based on structural flow - if it's a thing related to hmd then it should start with `HMD`, then if it's related to lock it follows-up by `LOCK` and then you select specific property (or sub-property) like `TARGET` and `POSITION` or simply `IS_OK`. Example:
```
HMD.LOCK.TARGET.POSITION
BLINDFOLD.COLOR
EAR_MUFFLES.ACTIVE
```

## Modules
If you're creating custom scenes or scripts then it should be placed in specific sub-folder in Modules directory. Sub-folder should have your GitHub username - see `H1M4W4R1` for reference. Also sub-folder should have following directories inside it: Scripts, Sprites, Scenes, Materials, even if unused.

## Namespaces
All scripts should be placed in `Modules.<GITHUB_NAME>` namespace.

## Hard-typing
It's forbidden to hard-type identifiers. This will result in PR denial. You can create `Identifiers` class within your namespace that will contain all IDs parts. For reference you can see already implemented one for core functions.

It's allowed to hard-type things like brackets.

## Invariant-Culture
Keep in mind that some countries had an [censored] who decided to use comma instead of dot as decimal point (he/she should burn in hell for that thing).

Please use `F()` and `S()` methods on `string` and `float` types to parse it using InvariantCulture.

There's also `V()` method to easily convert comma-separated list of floating strings into list of floats using `F()` method. Use `Count` property to get amount of elements in list.

## External plugins / assets
External assets are allowed only if its license is not violated by publishing them within this repository. `LICENSE` file should be included within asset / plugin folder. Otherwise Pull Request will be denied.

## If not mentioned
Check core scripts and try to keep as close convention as possible. This document may be updated if new conventions are required.

# Currently implemented core functions

## Blindfold `BLINDFOLD`
### Enable/Disable `*.ACTIVE` [GET, SET]
Activates or deactivates blindfold. Examples:
```
BLINDFOLD.ACTIVE=TRUE # Enable blindfold
BLINDFOLD.ACTIVE=FALSE # Disable blindfold
```
### Set Color `*.COLOR` [GET, SET]
Changes blindfold color using RGBA pallette (including transparency)
```
BLINDFOLD.COLOR=<0,0,0,0.5> # Half-transparent white blindfold
BLINDFOLD.COLOR=<1,0,0,1> # Red blindfold
```

## Hands and HMD `LEFT_HAND`, `RIGHT_HAND`, `HMD`
### Position `*.POSITION` [GET]
Get position of specific object in absolute world space.
### Rotation `*.ROTATION` [GET]
Get euler angles of specific object.

### Locks `*.LOCK` [GROUP]
Represents locking API - placement of markers controller should be located in to disable/enable external features.

#### Active `*.*.ACTIVE` [GET/SET]
Activate or deactivate lock (aka. draw lock object in world space)

#### Distance `*.*.DISTANCE` [GET]
Get distance between lock and its respective object (eg. left hand lock and left hand)

#### Is OK `*.*.IS_OK` [GET]
Returns TRUE or FALSE depending if distance is within requested tolerance

#### Target `*.*.TARGET` [GROUP]
Represents target parameters of current lock.

##### Position `*.*.*.POSITION` [GET/SET]
Target position - move lock target in absolute world space. 

##### Distance `*.*.*.DISTANCE` [GET/SET]
Target distance - how far controller/hmd can be from object to be considered within range. Also scales rendered object.

# Configuration `CONFIG`

## User-Config `*.USER` [GROUP]
Configurations related to user (player)

### Height `*.*.HEIGHT` [GET, SET]
Set user height for XR rig (aka. match real-world and in-game height for better experience)

## Room-Config `*.ROOM` [GROUP]
Configurations related to room (scene)

### Offset `*.*.OFFSET` [GET, SET]
Set room offset (to place scene are and real-world play area in desired locations).