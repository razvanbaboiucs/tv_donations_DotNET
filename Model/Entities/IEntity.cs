﻿﻿using System;

  namespace Model.Entities
{
    public interface IEntity <TId>
    {
        TId GetId();
        void SetId(TId id);
    }
}