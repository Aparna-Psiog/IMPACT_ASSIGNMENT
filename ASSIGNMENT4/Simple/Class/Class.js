class Vehicle {

    constructor(name, brand, color) {
    
      this.name = name;
      this.brand = brand;
      this.color = color;
    }
  
    describecar(){
      console.log("Name :" + this.name );
      console.log("Brand: " + this.brand + " " + "Color:" +this.color);
    }
  
  }
  
  const figo = new Vehicle('Figo', 'Ford', 'Green');
  figo.describecar();
  
  const estilo = new Vehicle('Zen Estilo', 'Maruti', 'Brown');
 estilo.describecar();