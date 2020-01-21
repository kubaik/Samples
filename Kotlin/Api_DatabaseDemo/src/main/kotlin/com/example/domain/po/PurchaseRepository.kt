package com.example.domain.po

import com.example.domain.po.PurchaseOrder
import org.springframework.data.jpa.repository.JpaRepository

interface PurchaseRepository: JpaRepository<PurchaseOrder, Int>