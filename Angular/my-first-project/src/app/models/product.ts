export class Product {

  static all = [
    new Product(1, 'Banana', 'banana', 10),
    new Product(2, 'Maça', 'maça', 11),
    new Product(3, 'Laranja', 'laranja', 750),
    new Product(4, 'Uva', 'uva', 34),
    new Product(5, 'Jabuticaba', '', 800)
  ];

  constructor(
    public id: number,
    public name: string,
    public description: string,
    public price: number) { }
}
