### 📘 **Documentation: AddServiceByLifetime<TMarker>**

```csharp
public static IServiceCollection AddServiceByLifetime<TMarker>(
this IServiceCollection services,
Func<IServiceCollection, Type, Type, IServiceCollection> addService,
Assembly[] assemblies,
ILogger? logger = null)
```

#### ✅ **Description:**

This function automatically registers services in a Dependency Injection Container based on the generic type `TMarker`. It is used to examine specific types of assemblies, registering them by the interface that inherits from `TMarker` or by the type itself if there are no direct interfaces.

#### 🧠 **Parameters:**

| Parameter | Type | Description |
| ------------ | ---------------------------------------------------------- | ------------------------------------------------------------------------------- |

| `services` | `IServiceCollection` | The collection of services to register the services to. |

| `addService` | `Func<IServiceCollection, Type, Type, IServiceCollection>` | A function that specifies how to add the service to the collection (e.g., `AddScoped`, `AddSingleton`, etc.). |

| `assemblies` | `Assembly[]` | The collection of assemblies to check for types. If not passed, the current assembly is used. |

| `logger` | `ILogger?` | An optional object to log error messages, warnings, and information during logging. |

#### 📋 **Conditions:**

* The type `TMarker` is used as a marker to specify which types should be registered.
* The type is registered either with its direct interfaces that inherit from `TMarker` or by itself if no interfaces exist.
* Abstract types or interfaces are ignored.

#### 🔁 **Behavior:**

* Scans all types within each assembly.
* Abstract types and interfaces are ignored.
* If the type inherits from `TMarker`:

* Direct interfaces (not those inherited from other interfaces) are specified.
* The service is registered with the interface if it was not previously registered.
* If no interfaces exist, the service is registered by itself.

#### 🧾 **Output:**

* Returns the same `IServiceCollection` object with its modifications.

#### ⚠️ **Logging Examples:**

```csharp
services.AddServiceByLifetime<IMyService>(
(svc, serviceType, implType) => svc.AddScoped(serviceType, implType),
new[] { typeof(MyService).Assembly },
logger);
```

#### 💡 **Notes:**

* This approach helps reduce manual redundancy when registering services.
* It can be used to register services based on specific interfaces only.
* Useful in large projects with many services.

---