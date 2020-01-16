package repository

import domain.Product

interface ProductRepository: JpaRepository<Product, Int>