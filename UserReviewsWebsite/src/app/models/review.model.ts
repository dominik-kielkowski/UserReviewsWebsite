export class Review{
    public Title: string;
    public ReviewBody: string;
    public Score: number;
    public ProductId: number;
    public UserId: number;

    constructor(title: string, reviewBody: string, score: number, productId: number, userId: number) {
        this.Title = title;
        this.ReviewBody = reviewBody;
        this.Score = score;
        this.ProductId = productId;
        this.UserId = userId;
    }
}