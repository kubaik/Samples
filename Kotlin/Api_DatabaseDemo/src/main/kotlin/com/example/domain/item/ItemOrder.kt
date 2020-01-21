package com.example.domain.item

import com.example.domain.product.Product
import com.example.domain.po.PurchaseOrder
import java.math.BigDecimal
import javax.persistence.*

@Entity
data class ItemOrder(
        @Id
        @GeneratedValue(strategy =  GenerationType.IDENTITY)
        @Column(name = "item_id")
        var id: Int? = null,
        @ManyToOne
        val product: Product = Product(),
        val quantity: Int = 0,
        val value: BigDecimal = BigDecimal(0),
        @ManyToOne
        val purchaseOrder: PurchaseOrder = PurchaseOrder()
)