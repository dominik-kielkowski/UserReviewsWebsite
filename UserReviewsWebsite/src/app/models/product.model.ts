export class Product{
    public Name: string;
    public Description: string;
    public ImagePath: string;

    constructor(name: string, description: string, imagePath: string) {
        this.Name = name;
        this.Description = description;
        this.ImagePath = imagePath;
    }
}