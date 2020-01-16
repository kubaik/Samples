package domain

import javax.persistence.*

@Entity
data class PurchaseOrder(
    @Id
    @GeneratedValue
    @Column(name = "purchase_id")
    var id: Int? = null,
    val customer: String = "",
    @OneToMany(mappedBy = "purchaseOrder", cascade = arrayOf(CascadeType.ALL))
    val items: List<ItemOrder> = mutableListOf()
)