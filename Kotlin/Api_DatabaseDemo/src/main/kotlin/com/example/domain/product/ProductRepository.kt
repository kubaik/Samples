package com.example.domain.product

import com.example.domain.product.Product
import org.springframework.data.jpa.repository.JpaRepository

interface ProductRepository: JpaRepository<Product, Int>
