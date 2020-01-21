package com.example.domain.po

import com.example.domain.item.ItemOrder
import javax.persistence.*

@Entity
data class PurchaseOrder(
        @Id
        @GeneratedValue(strategy =  GenerationType.IDENTITY)
        @Column(name = "purchase_id")
        var id: Int? = null,
        val customer: String = "",
        @OneToMany(mappedBy = "purchaseOrder", cascade = arrayOf(CascadeType.ALL))
        val items: List<ItemOrder> = mutableListOf()
)