package com.example

import org.springframework.boot.SpringApplication
import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class DemoApplication

fun main(args: Array<String>) {
//	runApplication<DemoApplication>(*args)
	SpringApplication.run(DemoApplication::class.java, *args)
}
