using System;
using System.Collections.Generic;
using DarkRift;
using DarkRift.Server;
using ServerPlugins.Game.Entities;
using Utilities.Game;

namespace ServerPlugins.Game.Components
{
    public abstract class Component
    {
        public Entity Entity;

        public virtual void Start() { }
        public virtual void Update(float delta) { }
        public virtual void Destroy() { }
    }
}