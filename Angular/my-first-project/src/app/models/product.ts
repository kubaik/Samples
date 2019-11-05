export class Product {

  static all = [
    new Product(1, 'Banana', 'banana'),
    new Product(2, 'Maça', 'maça'),
    new Product(3, 'Laranja', 'laranja'),
    new Product(3, 'Uva', 'uva'),
    new Product(3, 'Jabuticaba', '')
  ];

  constructor(
    public id: number,
    public name: string,
    public description: string) { }
}
