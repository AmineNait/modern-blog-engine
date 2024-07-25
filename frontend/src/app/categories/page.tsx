'use client';

import { useEffect, useState } from 'react';
import api from '../../utils/api';
import CategoryList from '../../components/CategoryList';

interface Category {
  id: number;
  name: string;
}

const CategoriesPage = () => {
  const [categories, setCategories] = useState<Category[]>([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get('/categories');
        setCategories(response.data);
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    };

    fetchCategories();
  }, []);

  return (
    <div>
      <h1>Categories</h1>
      <CategoryList categories={categories} />
    </div>
  );
};

export default CategoriesPage;
