﻿using Order.Domain.Bases;

namespace Order.Domain.Events;

public record OrderUpdatedEvent(Models.Order order) : IDomainEvent;