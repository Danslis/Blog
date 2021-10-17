import { Component } from '@angular/core'
import { Observable } from 'rxjs';
import { Post } from 'src/app/interfaces/postResponse';
import { PostsService } from 'src/app/service/post.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent {
  posts$: Observable<Post[]>;
  posts: Post[];
  loading: boolean = false;
  constructor(private postsService: PostsService) {
   }

  ngOnInit(): void {
    this.postsService.getPosts().subscribe((data: Post[])=>{
      this.posts = data;
      this.loading = true;
    });
  }
  onDeletePost(post: any) {
    this.posts = this.posts.filter(x => x.id !== post.id);
}
}
