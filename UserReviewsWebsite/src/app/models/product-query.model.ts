export class ProductQuery{
    public SearchPhrase: string;
    public PageNumber: number;
    public PageSize: number;
    public SortBy: string;
    public SortDirection: string;

    constructor(searchPhrase: string, pageNumber: number, pageSize: number, sortBy: string, sortDirection: string) {
        this.SearchPhrase = searchPhrase;
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.SortBy = sortBy;
        this.SortDirection = sortDirection;
    }
}