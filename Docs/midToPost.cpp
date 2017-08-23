#include<stdio.h>
#include<malloc.h>
#define StackMaxSize 30
typedef struct stack
{
	char stack[StackMaxSize];
	int top;
}STACK;
int Pre(char op)
{
	switch (op)
	{
	case '+':
	case '-':
		return 1;
	case '*':
	case '/':
		return 2;
	case '(':
	case '\n':
	default:
		return 0;
	}
}
char *Change(char *s1)
{
	STACK s;
	int i = 0, j = 0;
	char ch, *s2;
	s2 = malloc(sizeof(char));
	s.top = -1;
	s.stack[++s.top] = '\n';
		ch = s1[i++];
	while (ch != '\n')
	{
		if (ch == '(')
		{
			s.stack[++s.top] = ch;
			ch = s1[i++];
		}
		else if (ch == ')')
		{
			while (s.stack[s.top] != '(')
			{
				s2[j++] = s.stack[s.top–];
			}
			s.top–;
			ch = s1[i++];
		}
		else if (ch == '+' || ch == ' - '|| ch == '*' || ch == '/ ')
		{
			while (Pre(s.stack[s.top]) >= Pre(ch))
			{
				s2[j++] = s.stack[s.top–];
			}
			s.stack[++s.top] = ch;
			ch = s1[i++];
		}
		else
		{
			s2[j++] = ch;
			ch = s1[i++];
		}
	}
	ch = s.stack[s.top–];
	while (ch != '\n')
	{
		s2[j++] = ch;
		ch = s.stack[s.top–];
	}
	s2[j++] = '\n';return s2;
}

int main()
{
	int i = 1, j = 1;
	char c, *s1, *s2;
	s1 = malloc(sizeof(char));
	printf("请输入中缀表达式\n");
	while ((c = getchar()) != '\n')
	{
		s1[i++] = c;
	}
	s1[i] = '\n';
	printf("\n");
	s2 = Change(s1);
	printf("转换后的中缀表达式\n");
	while (s2[j] != '\n')
		printf("%c", s2[j++]);
	printf("\n");
	return 0;
}
CopyRight @ 2014 算法分析与设计精品课