import { Component, OnDestroy, OnInit } from '@angular/core'
import { Subscription } from 'rxjs';
import { Post } from 'src/app/interfaces/postResponse';
import { PostsService } from 'src/app/service/post.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit, OnDestroy {
  sub: Subscription;
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

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onDeletePost(post: any) {
    this.posts = this.posts.filter(x => x.id !== post.id);
}
}
