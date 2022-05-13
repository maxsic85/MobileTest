﻿using System.Collections.Generic;

public interface IRepository<TKey, TValue>
{ 
IReadOnlyDictionary<TKey, TValue> Content { get; }
}