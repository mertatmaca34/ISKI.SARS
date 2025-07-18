﻿namespace ISKI.Core.Domain;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
