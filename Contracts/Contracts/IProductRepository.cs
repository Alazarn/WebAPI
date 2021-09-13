﻿using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product GetProduct(Guid productId, bool trackChanges);
        void CreateProduct(Product product);
        IEnumerable<Product> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
