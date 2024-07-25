'use client';

import { useEffect, useState } from 'react';
import api from '../../utils/api';
import PostList from '../../components/PostList';

interface Post {
  id: number;
  title: string;
  content: string;
  categoryId: number;
}

const PostsPage = () => {
  const [posts, setPosts] = useState<Post[]>([]);

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const response = await api.get('/posts');
        setPosts(response.data);
      } catch (error) {
        console.error('Error fetching posts:', error);
      }
    };

    fetchPosts();
  }, []);

  return (
    <div>
      <h1>Posts</h1>
      <PostList posts={posts} />
    </div>
  );
};

export default PostsPage;
