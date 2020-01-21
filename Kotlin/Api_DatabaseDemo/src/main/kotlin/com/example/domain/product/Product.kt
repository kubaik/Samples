package com.example.domain.product

import javax.persistence.*

@Entity
data class Product(

    @Id
    @GeneratedValue(strategy =  GenerationType.IDENTITY)
    @Column(name = "product_id")
    var id: Int? = null,
    var description: String = ""
)