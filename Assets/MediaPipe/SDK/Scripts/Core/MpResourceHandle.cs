using System;

namespace Mediapipe {
  public abstract class MpResourceHandle : DisposableObject, IMpResourceHandle {
    protected IntPtr ptr;

    protected MpResourceHandle(bool isOwner = true) : this(IntPtr.Zero, isOwner) {}

    protected MpResourceHandle(IntPtr ptr, bool isOwner = true) : base(isOwner) {
      this.ptr = ptr;
    }

    public IntPtr ReleaseMpPtr() {
      var retPtr = mpPtr;
      ptr = IntPtr.Zero;

      return retPtr;
    }

    public IntPtr mpPtr {
      get {
        ThrowIfDisposed();
        return ptr;
      }
    }

    protected override void DisposeUnmanaged() {
      ptr = IntPtr.Zero;
      base.DisposeUnmanaged();
    }

    protected bool OwnsResource() {
      return isOwner && ptr != IntPtr.Zero;
    }
  }
}
